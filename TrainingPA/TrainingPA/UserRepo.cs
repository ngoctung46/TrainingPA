using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingPA
{
    public class UserRepo
    {
        public static List<User> data = new List<User>(){
            new User
            {
                Role = "Admin",
                Passcode = "123"
            },
            new User
            {
                Role = "Staff1",
                Passcode = "4444"
            },
            new User
            {
                Role = "Staff2",
                Passcode = "3333"
            },
            new User
            {
                Role = "Staff3",
                Passcode = "2222"
            },
            new User
            {
                Role = "Staff4",
                Passcode = "1111"
            }
        };
        public static int SelectedIndex { get; set; }
    }
}
