using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class Rental
    {

        [Key]
        public int Rental_id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Rental_date { get; set; }

        [Required]
        public int Inventory_id { get; set; }
        [Required]
        public int Customer_id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Return_date { get; set; }

        [Required]
        public Byte Staff_id {get; set; }

        [Required]
        public DateTime Last_update { get; set; }


/*
USE[sakila]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE[dbo].[rental]
        (

   [rental_id][int] IDENTITY(1,1) NOT NULL,
   [rental_date] [datetime]  NOT NULL,
   [inventory_id] [int] NOT NULL,
   [customer_id] [int] NOT NULL,
   [return_date] [datetime] NULL,
   [staff_id] [tinyint] NOT NULL,
   [last_update] [datetime] NOT NULL,

PRIMARY KEY NONCLUSTERED
(
    [rental_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[rental] ADD DEFAULT(NULL) FOR[return_date]
GO

ALTER TABLE[dbo].[rental] ADD CONSTRAINT[DF_rental_last_update]  DEFAULT(getdate()) FOR[last_update]
GO

ALTER TABLE[dbo].[rental] WITH CHECK ADD CONSTRAINT[fk_rental_customer] FOREIGN KEY([customer_id])
REFERENCES[dbo].[customer]
        ([customer_id])
GO

ALTER TABLE[dbo].[rental]
        CHECK CONSTRAINT[fk_rental_customer]
GO

ALTER TABLE[dbo].[rental] WITH CHECK ADD CONSTRAINT[fk_rental_inventory] FOREIGN KEY([inventory_id])
REFERENCES[dbo].[inventory]
        ([inventory_id])
GO

ALTER TABLE[dbo].[rental]
        CHECK CONSTRAINT[fk_rental_inventory]
GO

ALTER TABLE[dbo].[rental] WITH CHECK ADD CONSTRAINT[fk_rental_staff] FOREIGN KEY([staff_id])
REFERENCES[dbo].[staff]
        ([staff_id])
GO

ALTER TABLE[dbo].[rental]
        CHECK CONSTRAINT[fk_rental_staff]
GO

*/
    }
}


