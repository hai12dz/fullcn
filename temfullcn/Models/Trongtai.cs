using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace temfullcn.Models;

public partial class Trongtai
{
    public string TrongTaiId { get; set; } = null!;

    public string? HoVaTen { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? QueHuong { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Quốc tịch chỉ được nhập chữ.")]
    public string? QuocTich { get; set; }

    public int? SoNamKinhNghiem { get; set; }

    [RegularExpression(@"^.*\.png$", ErrorMessage = "Ảnh chỉ có phần mở rộng .png.")]
    public string? Anh { get; set; }

    public virtual ICollection<TrongtaiTrandau> TrongtaiTrandaus { get; set; } = new List<TrongtaiTrandau>();
}
