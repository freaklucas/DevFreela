using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    int Create(CreateUserInputModel inputModel);
    UserViewModel GetUser(int id);
    //oid Update(UpdateUserInputModel inputModel);
   // void Delete(int id);
}