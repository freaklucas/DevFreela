using DevFreela.Core.Enums;

namespace DevFreela.Application.InputModels;

public class UpdateProjectInputModel
{
    public UpdateProjectInputModel(
        string title, 
        string description, 
        int idClient, 
        int idFreelancer, 
        decimal totalCost, 
        DateTime finishedAt
        )
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal TotalCost { get; set; }
}