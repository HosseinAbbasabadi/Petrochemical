﻿using Petrochemical.Domain.ArticleCategoryAgg;

namespace Petrochemical.Infrastructure.EfCore.Repository;

public class ArticleCategoryRepository : IArticleCategoryRepository
{
    private readonly PetroContext _context;

    public ArticleCategoryRepository(PetroContext context)
    {
        _context = context;
    }

    public void Create(ArticleCategory entity)
    {
        _context.ArticleCategories.Add(entity);
    }

    public List<ArticleCategory> GetAll()
    {
        return _context.ArticleCategories.ToList();
    }

    public ArticleCategory GetById(long id)
    {
        return _context.ArticleCategories.First(x => x.Id == id);
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}