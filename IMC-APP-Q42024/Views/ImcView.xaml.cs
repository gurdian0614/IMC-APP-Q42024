using IMC_APP_Q42024.ViewModels;

namespace IMC_APP_Q42024.Views;

public partial class ImcView : ContentPage
{
	ImcViewModel viewModel;
	public ImcView()
	{
		InitializeComponent();
		viewModel = new ImcViewModel();
		BindingContext = viewModel;
	}
}