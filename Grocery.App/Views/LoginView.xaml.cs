using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private void OnQuickRegisterClicked(object sender, EventArgs e)
	{
		if (BindingContext is LoginViewModel vm)
		{
			vm.QuickRegisterFromUI();
		}
	}
}