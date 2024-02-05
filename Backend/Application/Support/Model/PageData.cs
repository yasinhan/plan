using System;
using System.Collections.Generic;
using System.Linq;

namespace plan.Backend.Application.Model;

public class PageData<T>(List<T>? data, int total, int curPage, int totalPage)
{
    public readonly List<T>? Data = data;

    public readonly int Total = total;

    public readonly int CurPage = curPage;

    public readonly int TotalPage = totalPage;

    public static PageData<T> Empty(int total, int curPage, int totalPage)
    {
        return new PageData<T>(Array.Empty<T>().ToList(), total, curPage, totalPage);
    }
}