namespace DevFreela.Application.ViewModels;

public class UserViewModel
{
    public string FullName { get; set; }
    public string Email { get; set; }

    public UserViewModel(string name, string email)
    {
        FullName = name;
        Email = email;
    }
}