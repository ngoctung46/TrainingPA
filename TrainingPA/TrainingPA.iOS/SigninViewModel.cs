using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;

namespace TrainingPA.iOS
{
    public class SigninViewModel : ReactiveObject
    {
        private string role;
        private string passcode;
        private nint selectedRoleIndex = 0;


        private readonly ReactiveCommand<Unit, bool> loginCommand;
        private readonly ReactiveCommand<Unit, Unit> resetCommand;
        private readonly ReactiveCommand<string, Unit> updateCommand;
        

        public SigninViewModel()
        {
            var canLogin = this.WhenAnyValue(x => x.Passcode, (p) => !string.IsNullOrEmpty(p));
            this.loginCommand = ReactiveCommand.CreateFromObservable(this.LoginAsync, canLogin);
            this.resetCommand = ReactiveCommand.Create(() =>
           {
               Role = null;
               Passcode = null;
           });

            updateCommand = ReactiveCommand.Create<string>((param) => {
                Passcode += param;
                Console.Write($"Bind {Passcode}");
            });
        }

        private IObservable<bool> LoginAsync() => Observable.Return(UserRepo.data.Exists(u => u.Role == Role && u.Passcode == Passcode));
                                                          
            
        
      

        public ReactiveCommand<Unit, bool> LoginCommand => this.loginCommand;
        public ReactiveCommand<Unit, Unit> ResetCommand => this.resetCommand;
        public ReactiveCommand<string, Unit> UpdateCommand => this.updateCommand;
        public string Role
        {
            get { return role; }
            set { this.RaiseAndSetIfChanged(ref role, value); }
        }

        public nint SelectedRoleIndex
        {
            get { return selectedRoleIndex; }
            set { this.RaiseAndSetIfChanged(ref selectedRoleIndex, value); }
        }

        public string Passcode
        {
            get { return passcode; }
            set { this.RaiseAndSetIfChanged(ref passcode, value); }
        }


            
    }
}