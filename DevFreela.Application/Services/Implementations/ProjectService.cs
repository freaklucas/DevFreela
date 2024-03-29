﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _dbContext;

    public ProjectService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<ProjectViewModel> GetAll(string query)
    {
        var projects = _dbContext.Projects;
        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

        return projectsViewModel;
    }

    public ProjectDetailsViewModel GetById(int id)
    {
        var project = _dbContext.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .SingleOrDefault(p => p.Id == id);
        if (project == null)
        {
            return null;
        }

        var projectDetailsViewModel = new ProjectDetailsViewModel(
            project.Id,
            project.Title,
            project.Description,
            project.TotalCost,
            project.StartedAt,
            project.FinishedAt,
            project.Client.FullName,
            project.Freelancer.FullName
        );

        return projectDetailsViewModel;
    }

    public int Create(NewProjectInputModel inputModel)
    {
        var project = new Project(
            inputModel.Title,
            inputModel.Description,
            inputModel.IdClient,
            inputModel.IdFreelancer,
            inputModel.TotalCost
        );

        _dbContext.Projects.Add(project);
        _dbContext.SaveChanges();

        return project.Id;
    }

    public void CreateComment(CreateCommentInputModel inputModel)
    {
        var comment = new ProjectComment(
            inputModel.Content,
            inputModel.IdProject,
            inputModel.IdUser
        );
        // TODO: SÓ FUNCIONA passando ID do projeto >= 6
        _dbContext.ProjectComments.Add(comment);
        _dbContext.SaveChanges();
    }
    
    // TODO: encontrar id do projeto
    public List<ProjectComment> GetCreatedComments()
    {
        var findProject = _dbContext.ProjectComments;

        var projectsViewModel = findProject
            .Select(p => new ProjectComment(p.Content, p.IdProject, p.IdUser))
            .ToList();

        return projectsViewModel;
    }
    
    public void Update(int id, UpdateProjectInputModel inputModel)
    {
        var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
        if (project == null)
        {
            return;
        }

        project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        _dbContext.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var findProject = _dbContext.Projects.FirstOrDefault(x => x.Id == id);

        findProject.Cancel();
        
        _dbContext.Remove(findProject);
        _dbContext.SaveChanges();
    }
    public void Start(int id)
    {
        var project = _dbContext.Projects.FirstOrDefault(x => x.Id == id);

        project.Start();
        _dbContext.SaveChanges();
    }

    public void Finish(int id)
    {
        var project = _dbContext.Projects.FirstOrDefault(x => x.Id == id);

        project.Finished();
        _dbContext.SaveChanges();
    }
}
