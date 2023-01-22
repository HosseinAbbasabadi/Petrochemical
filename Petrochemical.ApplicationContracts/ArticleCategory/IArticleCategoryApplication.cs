﻿using _0_Framework.Application;

namespace Petrochemical.ApplicationContracts.ArticleCategory;

public interface IArticleCategoryApplication : IApplication
{
    OperationResult Create(ArticleCategoryOps command);
    void Edit(ArticleCategoryOps command);
    void Remove(long id);
    void Restore(long id);
}