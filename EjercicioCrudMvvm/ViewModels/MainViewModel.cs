using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCrudMvvm.Models;
using EjercicioCrudMvvm.Services;
using EjercicioCrudMvvm.Views;
using EjercicioCrudMvvm.ViewModels;

namespace EjercicioCrudMvvm.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Proveedor> proveedorCollection = new ObservableCollection<Proveedor>();

        private readonly ProveedoresService _service;

        public MainViewModel()
        {
            _service = new ProveedoresService();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var getAll = _service.GetAll();

            if (getAll.Count > 0)
            {
                proveedorCollection.Clear();
                foreach (var empleado in getAll)
                {
                    proveedorCollection.Add(empleado);
                }
            }
        }

        [RelayCommand]
        private async Task GoToAddEditView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView());
        }

        [RelayCommand]
        private async Task SelectEmpleado(Proveedor proveedor)
        {
            try
            {
                const string ACTUALIZAR = "Actualizar";
                const string ELIMINAR = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);
                if (res == ACTUALIZAR)
                {
                    await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView(proveedor));
                }
                else if (res == ELIMINAR)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR EMPLEADO", "¿Dese eliminar el empleado?", "Si", "No");
                    if (respuesta)
                    {
                        int del = _service.Delete(proveedor);

                        if (del > 0)
                        {
                            Alerta("ELIMINAR EMPLEADO", "Empleado eliminado correctamente.");
                            ProveedorCollection.Remove(proveedor);

                        }
                        else
                        {

                            Alerta("ELIMINAR EMPLEADO", "No se eliminó el empleado");
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                Alerta("ERROR", ex.Message);
            }
        }
    }
}
