using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCrudMvvm.Models;
using EjercicioCrudMvvm.Services;

namespace EjercicioCrudMvvm.ViewModels
{
    public partial class AddEditViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string direccion;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string producto;

        private readonly ProveedoresService _service;

        public AddEditViewModel()
        {
            _service = new ProveedoresService();
        }

        public AddEditViewModel(Proveedor proveedor) {

            _service = new ProveedoresService();
            Id = proveedor.Id;
            Nombre = proveedor.Nombre;
            Direccion = proveedor.Direccion;
            Email = proveedor.Email;
            Producto = proveedor.Producto;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate() 
        {
            try
            {

                Proveedor proveedor = new Proveedor
                {
                    Id = Id,
                    Nombre = Nombre,
                    Direccion = Direccion,
                    Email = Email,
                    Producto = Producto
                };
                if (proveedor.Nombre is null || proveedor.Nombre == "")
                {
                    Alerta("Advertencia", "Ingrese el nombre");
                }
                else
                {
                    if (Id == 0)
                    {
                        _service.Insert(proveedor);
                    }
                    else
                    {
                        _service.Update(proveedor);

                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            { 
             Alerta("Error",ex.Message);
            
            }    
        
        }
    }
}
