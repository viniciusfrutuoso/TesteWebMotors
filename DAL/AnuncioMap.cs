using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using DTO;

namespace DAL
{
    public class AnuncioMap : EntityTypeConfiguration<Anuncio>
    {
        public AnuncioMap()
        {
            //table
            this.ToTable("tb_AnuncioWebmotors", "dbo");

            //PK
            this.HasKey(t => t.Id);

            //Columns
            this.Property(t => t.Marca)
                .HasColumnName("marca")
                .IsRequired()
                .HasMaxLength(45);


            this.Property(t => t.Modelo)
                .HasColumnName("modelo")
                .IsRequired()
                .HasMaxLength(45);

            this.Property(t => t.Versao)
                .HasColumnName("versao")
                .IsRequired()
                .HasMaxLength(45);

            this.Property(t => t.Ano)
                .HasColumnName("ano")
                .IsRequired();


            this.Property(t => t.Quilometragem)
            .HasColumnName("quilometragem")
            .IsRequired();

            this.Property(t => t.Observacao)
            .HasColumnName("observacao")
            .IsRequired();

         











        }


    }
}