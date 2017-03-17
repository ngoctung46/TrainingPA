using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TrainingPA.iOS
{
    public class RoleModel : UIPickerViewModel
    {
        List<User> pickerData;
        UIButton view;
        SigninViewModel viewModel;
        public RoleModel(UIButton view, SigninViewModel viewModel)
        {
            pickerData = new List<User>();
            for (int i = 0; i < UserRepo.data.Count - 1; i++)
            {
                pickerData.Add(UserRepo.data[i]);
            }
            this.view = view;
            this.viewModel = viewModel;
            
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return pickerData.Count;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return pickerData[(int)row].Role;
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            view.SetTitle(pickerData[(int)row].Role, UIControlState.Normal);
            viewModel.SelectedRoleIndex = row;
            pickerView.Hidden = !pickerView.Hidden;
        }
        

       
    }
}