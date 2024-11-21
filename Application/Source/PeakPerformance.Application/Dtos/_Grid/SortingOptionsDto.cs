﻿namespace PeakPerformance.Application.Dtos._Grid;

public class SortingOptionsDto
{
    public string Field { get; set; }

    private string _dir;

    public string Dir { set => _dir = value; }

    public bool Desc => _dir == Constants.SORTING_ORDER_DESC;
}