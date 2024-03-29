﻿using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;

namespace DevFreela.Application.Services.Interfaces;

public interface IProjectService
{
    List<ProjectViewModel> GetAll(string query);
    ProjectDetailsViewModel GetById(int id);
    int Create(NewProjectInputModel inputModel);
    void Update(int id, UpdateProjectInputModel inputModel);
    void Delete(int id);
    void CreateComment(CreateCommentInputModel inputModel);
    List<ProjectComment> GetCreatedComments();
    void Start(int id);
    void Finish(int id);
}

