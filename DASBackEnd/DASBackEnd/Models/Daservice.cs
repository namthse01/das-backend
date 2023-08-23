using System;
using System.Collections.Generic;

namespace DASBackEnd.Models;

public partial class Daservice
{
    public int Id { get; set; }

    public string? ServiceName { get; set; }

    public string? Intro { get; set; }

    public string? Contents { get; set; }

    public string? Outro { get; set; }

    public int? LowPrice { get; set; }

    public int? AdvancedPrice { get; set; }

    public int? TopPrice { get; set; }

    public string? ImgUrl { get; set; }

    public int? AccountId { get; set; }

    public int? ServiceIsActive { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; } = new List<BookingDetail>();
}
