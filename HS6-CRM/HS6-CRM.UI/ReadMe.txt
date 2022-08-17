Project Art.
Struct:

UI= kullanıcının göreceği ekranların bulunduğpu katman
BL=(bussiness logic) :kullanıcının iş analitiğinin yapıldığı katman
DAL(Data access layer)= Db erişim katmanı
core=diğer katmanların ihtiyaç duyduğu nesneleri işlemlerin bulunduğu katman
entities= db tarafında bulunan tabloların nesnelerinin bulunduğu katman
dto= data transfer object= Entities katmanı ile uı dan gelen verirnin map edildiği katmandır.

Pattern:

Repository Pattern= Dal katmanına db erişim işlemleri için kullanılacak olan patterndir.