﻿namespace Models;

public record ItemDTO(string Text, bool IsCompleted, DateTime CreatedDate, DateTime CompletedDate)
{
}