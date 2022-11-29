# degisen_top
<img width="580" alt="image" src="https://user-images.githubusercontent.com/75569106/204596148-c610b271-c95b-461b-8fc4-d13a2c43f57d.png">

<br/>![oyundan görüntüler](
https://cdn-images-1.medium.com/max/1200/1*coIelHPopam5hBhJY0IGZQ.png) <br/>
unity oyun programlama dersi Arrow tuşlarıyla renklere göre cismin boyutunun ve renginin  değiştiği oyun
oyun 5 can içeren gerekli koşullarda boyutu büyüyüp küçülebilen puan odaklı bir platfrom oyunudur.

# PROJE GENEL ÖZET
// https://simmer.io/@humeyracimen/degisen-top
manager_sc : rastegle konum ve sürede random olarak ürtilen nesnelerin kontrolunun saglandıgı kısım 
[SerializeField]
    private GameObject şeklinde unity penceresinden erişim yapıldı ve gerekli komponentler (sarı top, kırmızı top ,yeşil top ve siyah blok) verildi.
    
    start fonksiyonu içerisinde çagırılan fonksiyonlar 
    `"  StartCoroutine(manager_bigger());
        StartCoroutine(manager_smaller());
        StartCoroutine(manager_block());
        StartCoroutine(manager_bonus()); " ` bu şekilde ayarlanan süre bazında random konumlarda ilgili komponenti oluşturan kod blogu tasarlandı. 
        random konum ve fonksiyonun çağırılma süresinin ayarlamalarına ait kulllanılan kodlardan biri :
        
        
    `"      IEnumerator manager_bigger(){
        while(true){
            dynamic_z+=Random.Range(5,20);
            Vector3 position = new Vector3(Random.Range(-5f, 5f), 0,transform.position.z+dynamic_z );
            GameObject bigger = Instantiate(bigger_pf, position, Quaternion.identity);
            bigger.transform.parent = bigger_container.transform;
            yield return new WaitForSeconds(1.0f);   
        }
    }
        " ` 
        
       oyun yoluna ait otomatik oluşturma için de 
     `   /*
        platform.transform.position =new Vector3(platform.transform.position.x,platform.transform.position.y,z_offset+transform.position.z);
        platform2.transform.position =new Vector3(platform2.transform.position.x,platform2.transform.position.y,z_offset+transform.position.z);
        */ 
        " ` şeklinde tasarlandı ama oyuncunun hızına baglı olarak yolun bazen geride veya ileride olma sorunu sebebiyle farklı bir yol denendi .
