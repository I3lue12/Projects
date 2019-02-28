using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserInfo collects Info of the user and performs querys
/// </summary>
public class UserInfo
{
    public string UserName;
    public string Password;
    public string First, Last, EMail;
    public int Age;
    public bool IsMale;
    public AdminRights Rights;

    public UserInfo(string user, string pass, string first, string last, string email, int age , bool male, AdminRights rights)
    {
        UserName = user;
        Password = pass;
        First = first;
        Last = last;
        EMail = email;
        Age = age;
        IsMale = male;
        Rights = rights;
    }
    
}