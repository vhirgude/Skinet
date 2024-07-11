﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications;
public class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification()
    {
    }

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria=criteria;
    }

    public Expression<Func<T, bool>> Criteria  {get;}

    public List<Expression<Func<T, object>>> Includes  {get;}=new List<Expression<Func<T, object>>>();

    public Expression<Func<T, object>> OrderBy {get;private set;}

    public Expression<Func<T, object>> OrderByDesc {get; private set;}

    public int Take {get; private set;}

    public int Skip {get; private set;}

    public bool IsPaginationEnable {get; private set;}

    protected void AddInclude(Expression<Func<T,object>> includeexpression)
    {
        Includes.Add(includeexpression);
    }

    protected void AddOrderBy(Expression<Func<T,object>> orderByexpression)
    {
        OrderBy=orderByexpression;
    }

    protected void AddOrderByDesc(Expression<Func<T,object>> OrderByDescexpression)
    {
        OrderByDesc=OrderByDescexpression;
    }
    protected void ApplyPagination(int take,int skip)
    {
        Take=take;
        Skip=skip;
        IsPaginationEnable=true;
    }
}
