use [SMS_RAMPAGE]
select * from Purchase
select * from [dbo].[Product]
select * from [dbo].[Category]
select Purchase.Quantity from Purchase left join Product on Purchase.Product_id = Product.Id where Product.Name = 'Xiaomi'
insert into Purchase (Date1,InvoiceNo,Supplier_id,category_id,Product_id,Manufacture_Date,Expire_Date,Quantity,Unit_Price,MRP,
Remarks) values('2019-10-18',1234,2,1,10,'2019-10-18','2028-11-11',2,500,550,'Good quality')
insert into Purchase (Date1,InvoiceNo,Supplier_id,category_id,Product_id,Manufacture_Date,Expire_Date,Quantity,Unit_Price,MRP,
Remarks) values('2019-10-18',1235,1,3,5,'2019-10-18','2028-11-11',4,1000,1200,'Good quality')

insert into Purchase (Date1,InvoiceNo,Supplier_id,category_id,Product_id,Manufacture_Date,Expire_Date,Quantity,Unit_Price,MRP,
Remarks) values('2019-10-18',1235,2,4,13,'2019-10-18','2028-11-11',4,100,150,'Good quality')
select Purchase.Unit_Price from Purchase left join Product on Purchase.Product_id = Product.Id where Product.Name = 'Xiaomi'
delete from Purchase where id=3
select Purchase.Unit_Price from Purchase left join Product on Purchase.Product_id = Product.Id where Product.Name = 'Samsung'
select Purchase.Unit_Price from Purchase left join Product on Purchase.Product_id = Product.Id where Product.Name = 'Xiaomi'
select Purchase.Unit_Price from Purchase left join Product on Purchase.Product_id = Product.Id where Product.Name = 'Xiaomi'

