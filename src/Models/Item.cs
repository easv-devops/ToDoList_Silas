﻿namespace Models;

public class Item
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public bool IsComplete { get; set; }
}