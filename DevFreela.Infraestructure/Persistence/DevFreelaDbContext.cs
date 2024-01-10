using DevFreela.Core.Entities;

namespace DevFreela.Infraestructure.Persistence;

public class DevFreelaDbContext
{
    public DevFreelaDbContext()
    {
        Projects = new List<Project>
        {
            new Project("Meu projeto .net core", "Feito com clean code", 1, 1, 5000M),
            new Project("Meu projeto javascript", "Feito com vue.js", 1, 1, 2000M)
        };

        Users = new List<User>
        {
            new User("Lucas Oliveira", "lucas@gmail.com", new DateTime(1998,1,1)),
            new User("Sacul Arievilo", "sacul@gmail.com", new DateTime(2001,1,1))
        };

        Skills = new List<Skill>
        {
            new Skill("Descrição do projeto 1 - .Net core - C#"),
            new Skill("Descrição do projeto 2 - Javascript - Vue.js")
        };
    }
    public List<Project> Projects { get; private set; }
    public List<User> Users { get; private set; }
    public List<Skill> Skills { get; private set; }
}