﻿namespace EindomsHavnAPI.DTOs.ProductDtos;

public class GetByIdProductDetailsDto
{
    public Guid Id { get; set; }
    
    public Guid ProductId { get; set; }
    
    public int Size { get; set; }
    
    public byte BadromCount { get; set; }
    
    public byte BathCount { get; set; }
    
    public byte RomCount { get; set; }
    
    public byte GarageSize { get; set; }
    
    public string BuildYear { get; set; }
    
    public string Location { get; set; }
    
    public string VideoUrl { get; set; }
    
}