namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        /* Here we've created related entities. The reason we give it the full product type 
        *  and Id is to help out the Entity Framework so that when we create a new migration
        *  EF will know that our Product has a relation with ProductType and ProductBrand and
        *  will use the Ids as foreign keys
        */
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}