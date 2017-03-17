using Foundation;
using System;
using UIKit;

namespace TrainingPA.iOS
{
    public partial class PadController : UICollectionViewController
    {
        public PadController (IntPtr handle) : base (handle)
        {
            CollectionView.RegisterClassForCell(typeof(PadCell), "PadCell");
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var padCell = (PadCell)collectionView.DequeueReusableCell("PadCell", indexPath);
            var text = Pad.pads[indexPath.Row];
            padCell.Text = text;
            return padCell;
        }
    }
}