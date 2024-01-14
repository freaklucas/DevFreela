using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;

namespace DevFreela.Application.Services.Interfaces;

public interface ISkillService
{
    List<SkillViewModel> GetAll();
}
