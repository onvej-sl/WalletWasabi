using WalletWasabi.Fluent.ViewModels.Navigation;

namespace WalletWasabi.Fluent.ViewModels.AddWallet
{
	[NavigationMetaData(
		Title = "Terms and Conditions",
		Caption = "Displays terms and conditions",
		Order = 3,
		Category = "General",
		Keywords = new[] { "View", "Legal", "Docs", "Documentation", "Terms", "Conditions", "Help" },
		IconName = "info_regular",
		NavigationTarget = NavigationTarget.DialogScreen)]
	public partial class LegalDocumentsViewModel : RoutableViewModel
	{
		[AutoNotify] private string? _content;

		public LegalDocumentsViewModel(string content)
		{
			Content = content;
			NextCommand = BackCommand;
		}
	}
}
