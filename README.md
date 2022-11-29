# degisen_top


<br/>![oyundan görüntüler](
https://cdn-images-1.medium.com/max/1200/1*coIelHPopam5hBhJY0IGZQ.png) <br/>
# PROJE GENEL ÖZET
unity oyun programlama dersi Arrow tuşlarıyla renklere göre cismin boyutunun ve renginin  değiştiği oyun
oyun 5 can içeren gerekli koşullarda boyutu büyüyüp küçülebilen puan odaklı bir platfrom oyunudur.

# PROJE KULLANIMI
**1.yol :** Proje dosyasını  indirdikten sonra unity ile görüntüleyebilir ,gerekli talimatlar doğrultusunda oyunu oynayabilirsiniz.

<br/>**2.yol : [İletilen linke tıklamanız yeterli.](https://simmer.io/@humeyracimen/degisen-top )**
**manager_sc :<br/>  Rastegle konum ve sürede random olarak ürtilen nesnelerin kontrolunun saglandıgı kısım**
    `"[SerializeField]"` 
    private GameObject şeklinde unity penceresinden erişim yapıldı ve gerekli komponentler (sarı top, kırmızı top ,yeşil top ve siyah blok) verildi.

    start fonksiyonu içerisinde çagırılan fonksiyonlar belirlenen zaman aralıklarında fonksiyonların çagırılaması için gerekli komponentler: 
    `"  StartCoroutine(manager_bigger()); //** kırmızı topların rastgele z konumunda yer almalarını ve belirli zaman aralıklarında oluşsturulmasını saglar **<br/>
        StartCoroutine(manager_smaller()); //** yeşil topların rastgele z konumunda yer almalarını ve belirli zaman aralıklarında oluşsturulmasını saglar** <br/>
        StartCoroutine(manager_block()); // **siyah blokların rastgele zkonumunda yer almalarını ve belirli zaman aralıklarında oluşsturulmasını saglar** <br/>
        StartCoroutine(manager_bonus()); " ` // **sarı topların  rastgele z konumunda yer almalarını ve belirli zaman aralıklarında oluşsturulmasını saglar **<br/>
        <br/> Bu şekilde ayarlanan süre bazında random konumlarda ilgili komponenti oluşturan kod blogu tasarlandı. 
        random konum ve fonksiyonun çağırılma süresinin ayarlamalarına ait kulllanılan kodlar.
        
        ** kırmızı topların rastgele x konumunda yer almalarını ve belirli zaman aralıklarında oluşsturulmasını saglar **<br/>
    `"      IEnumerator manager_bigger(){
        while(true){
            dynamic_z+=Random.Range(5,20); // ilgili komponentlerin ne kadar ileriki konumda (z konumu ) bulunmalarını belirler
            Vector3 position = new Vector3(Random.Range(-5f, 5f), 0,transform.position.z+dynamic_z );
            **// yeni komponentin konumlandırılması (x,y,z) için:
            <br/>x: -7f /+7f boyutundaki yol (tag: ground1/2) aralıklarından birinde konumlanmasını sağlar , oyuncunun sag sol tuş hareketlerini kullandiğı kısım 
            <br/>y: sabit y konumunda devam etmesini sağlar 
            <br/> z: olusturulan dinamik konumuda ileriyi temsil eder oyuncunun yukarı tuşunu kullandıgı kısımdır (oyunda geriye dönem yoktur ! bu özellik engellenmiştir.) ilgili komponentler **
            GameObject bigger = Instantiate(bigger_pf, position, Quaternion.identity); // ilgili nesnenin prefabdan çekilmesi 
            bigger.transform.parent = bigger_container.transform;
            yield return new WaitForSeconds(1.0f);   // ilgili kodun ne kadar zaman aralıklarında çalıştırılacagının yönetimi
        }
    }
        " ` 
        
       oyun yoluna ait otomatik oluşturma için de 
     `   /*
        platform.transform.position =new Vector3(platform.transform.position.x,platform.transform.position.y,z_offset+transform.position.z);
        platform2.transform.position =new Vector3(platform2.transform.position.x,platform2.transform.position.y,z_offset+transform.position.z);
        */ 
        " ` şeklinde tasarlandı ama oyuncunun hızına baglı olarak yolun bazen geride veya ileride olma sorunu sebebiyle farklı bir yol denendi .
        Box Colldier ile tagları ground1 ve ground2 olan yol componentlerinin başlanşıc ve bitiş noktalarına componentler verildi .
        ve hızdan bagımsız olarak oyuncunun (tag :player) konumu ile iki yolun birbini takip etmesinin yönetimi yapıldı . sonsuz bir yol görünümü saglamak için başta olustuurlan iki yolun boyu oyuncuya farkettirilmeden yapılması için uzatıldı. 
`"ground1.transform.position += new Vector3(0, 0, ground2.localScale.z * 2);   " ` 
arkada kalan yol parçasının yeni konumunu öndeki yol parsının z konumunun iki katı kadar yap 1 katı için yapıldıgında iki yol üst üste bindi . yol devamlılıgı bu şeklide sagladı tabiki bir parçayı değil iki parçanında ilerleme kontorlu sağlandı. 

        
        `"private void OnTriggerExit(Collider other)
    {
        canObstacleControl = true; flag kontrolü ile canın sürekli azaltılamsı durumu kontrol edildi ObstacleControl fonksiyonunda can azalma  dan sonra flag  false olarak setlendi
    }"` 
     <br/>
        
**# player_sc  OnTriggerEnter fonksiyonu: **

`"   if (other.CompareTag("ball")) GetComponent<Renderer>().material.color = other.GetComponent<Renderer>().material.color; "` tagı ball olan nesnenin renginin player a atanmasını saglıyor  <br/>
  <br/>
**# ObstacleControl fonksiyonu :**
ayni renk topla ile eşleştiği durumda büyüyen ,kendinden farklı renk topla eşleştiği durumda boyutu küçülen fonsiyon .
 <br/>
 eşlesme durumundaki topların renk kontrolunü if blokları ile ben tarafından sağlanarak   can ve puan yönetimi bu fonksiyon içerisinde gerçekleştirildi.
  <br/>
  `"void GameOver()
    {
        
        endPanel.SetActive(true); 
        text.text="GAME OVER";   // oyun bittiğinde uı penceresindeki textde game over yazması için ayarlandı 
        Time.timeScale = 0; // başlama durumu setlenmesi 0 zamanında ki durum olarak ayarlandı
        
        
    } "`
    
    <br/>![oyundan görüntüler2]
    (https://cdn-images-1.medium.com/max/1200/1*prHQyZK19NM-6BllFOu1zA.png)<br/>
   <br/>  uı entegrasyonu sağlandı (kullanıcı paneli ) farklı ekran boyutuna göre boyut değişmemesi için scale with screen size ile sağlandı (1920 -1080 )uı panelide aynı boyutlara düzenlendi.
   <br/>  **gain_point_sc :** oyun yolunun 15 olması sebebiyle -14 +14 x konumları arasında rondom x üretilmesi sağlandı.


 <br/> <br/> <br/> <br/>
ekip arkadaşım irem tarafından:  <br/>
player_movement_sc : klavye girdileri ile oyuncunun hareketlenmesinin kontrolu  Input.GetAxis ile yapıldı . 
blok ile temsaında fizik kuralı uygulandı ve oyuncunun konumu geri çekildi .
yoldan oyuncunun çıkması durumunun kontolu sağlandı ve x konumunda yolun orta noktasına konumlandırıldı .
ObstacleControl fonksiyonunda  temas durumlarına göre player boyut ayarlaması sağlandı
uı tasarımı ve fonksiyonları yapıldı pauseMenu_sc.<br/><br/>
[irem atak repo](https://github.com/irematak/unity_3d_platform_oyunu-)







