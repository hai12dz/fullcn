using System;
using System.Collections.Generic;

namespace temfullcn.Models;

public partial class Trandau
{
    public string TranDauId { get; set; } = null!;

    public DateTime? NgayThiDau { get; set; }

    public string? Clbkhach { get; set; }

    public string? Clbnha { get; set; }

    public string? SanVanDongId { get; set; }

    public int? Vong { get; set; }

    public DateTime? HiepPhu { get; set; }

    public string? KetQua { get; set; }

    public bool? TrangThai { get; set; }

    public string? Anh { get; set; }

    public virtual Caulacbo? ClbkhachNavigation { get; set; }

    public virtual Caulacbo? ClbnhaNavigation { get; set; }

    public virtual Sanvandong? SanVanDong { get; set; }

    public virtual ICollection<TrandauCauthu> TrandauCauthus { get; set; } = new List<TrandauCauthu>();

    public virtual ICollection<TrandauGhiban> TrandauGhibans { get; set; } = new List<TrandauGhiban>();

    public virtual ICollection<TrongtaiTrandau> TrongtaiTrandaus { get; set; } = new List<TrongtaiTrandau>();
}
