
using EjercicioCrudMvvm.ViewModels;
using EjercicioCrudMvvm.Models;

namespace EjercicioCrudMvvm.Views;

public partial class AddEditView : ContentPage
{
	private AddEditViewModel viewModel;
	public AddEditView()
	{
        InitializeComponent();
        viewModel = new AddEditViewModel();
        this.BindingContext = viewModel;
    }
    public AddEditView(Proveedor proveedor)
    {
        InitializeComponent();
        viewModel = new AddEditViewModel(proveedor);
        this.BindingContext = viewModel;
    }
}