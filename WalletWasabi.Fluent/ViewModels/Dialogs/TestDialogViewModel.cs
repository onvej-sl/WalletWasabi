using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace WalletWasabi.Fluent.ViewModels.Dialogs
{
	public class TestDialogViewModel : DialogViewModelBase<bool>
	{
		private NavigationStateViewModel _navigationState;
		private string _message;

		public TestDialogViewModel(NavigationStateViewModel navigationState, NavigationTarget navigationTarget, string message) : base(navigationState, navigationTarget)
		{
			_navigationState = navigationState;
			_message = message;

			var cancelCommandCanExecute = this.WhenAnyValue(x => x.IsDialogOpen).ObserveOn(RxApp.MainThreadScheduler);

			var nextCommandCanExecute = this.WhenAnyValue(x => x.IsDialogOpen).ObserveOn(RxApp.MainThreadScheduler);

			CancelCommand = ReactiveCommand.Create(() => Close(false), cancelCommandCanExecute);
			NextCommand = ReactiveCommand.Create(() => Close(true), nextCommandCanExecute);
		}

		public string Message
		{
			get => _message;
			set => this.RaiseAndSetIfChanged(ref _message, value);
		}

		public ICommand NextCommand { get; }

		protected override void OnDialogClosed()
		{
			// TODO: Disable when using Dialog inside DialogScreenViewModel / Settings
			// _navigationState.HomeScreen?.Invoke().Router.NavigateAndReset.Execute(new SettingsPageViewModel(_navigationState));
		}

		public void Close()
		{
			// TODO: Dialog.xaml back Button binding to Close() method on base class which is protected so exception is thrown.
			Close(false);
		}
	}
}