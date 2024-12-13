using System;
using System.Collections.Generic;

namespace temfullcn.Models;

public partial class Sanvandong
{
    public string SanVanDongId { get; set; } = null!;

    public string? TenSan { get; set; }

    public string? ThanhPho { get; set; }

    public int? NamBatDau { get; set; }

    public string? Anh { get; set; }

    public virtual ICollection<Caulacbo> Caulacbos { get; set; } = new List<Caulacbo>();

    public virtual ICollection<Trandau> Trandaus { get; set; } = new List<Trandau>();
}
