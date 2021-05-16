using System;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace WalletWasabi.Fluent.ViewModels.Wallets.Home.Tiles
{
	public abstract partial class TileViewModel : ActivatableViewModel
	{
		[AutoNotify] private ObservableCollection<TilePresetViewModel>? _tilePresets;
		[AutoNotify] private int _tilePresetIndex;

		protected TileViewModel()
		{
			this.WhenAnyValue(x => x.TilePresetIndex)
				.Subscribe(_ => NotifyPresetChanged());
		}

		public int Column => CurrentTilePreset?.Column ?? 0;

		public int Row => CurrentTilePreset?.Row ?? 0;

		public int ColumnSpan => CurrentTilePreset?.ColumnSpan ?? 1;

		public int RowSpan => CurrentTilePreset?.RowSpan ?? 1;

		public bool IsVisible => CurrentTilePreset?.IsVisible ?? true;

		public TilePresetViewModel? CurrentTilePreset => TilePresets?[TilePresetIndex];

		private void NotifyPresetChanged()
		{
			this.RaisePropertyChanged(nameof(CurrentTilePreset));
			this.RaisePropertyChanged(nameof(Column));
			this.RaisePropertyChanged(nameof(Row));
			this.RaisePropertyChanged(nameof(ColumnSpan));
			this.RaisePropertyChanged(nameof(RowSpan));
			this.RaisePropertyChanged(nameof(IsVisible));
		}
	}
}