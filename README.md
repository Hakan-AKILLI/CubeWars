230206009                     Hakan AKILLI          Bilgisayar Mühendisliği  

Unity Proje Teknik Özet 

Proje Hakkında: CUBE WARS 

Bu proje, Unity oyun motoru kullanılarak geliştirilmiş, temel mekanikleri ve oyun döngüsüyle modern bir First-Person Shooter (FPS) deneyimi sunan bir çalışmadır. Oyunda temel amaç, haritanın farklı noktalarından (SpawnPoints) sürekli olarak üzerimize gelen düşman birimlerini etkisiz hale getirerek hayatta kalmaktır. Eğer 3 adet düşman öldürülemeden oyuncumuza dokursa oyun biter. Proje kapsamında; fizik tabanlı atış sistemleri (Raycast), kullanıcı arayüzü (UI) yönetimi ve görsel efektlerin kodla kontrolü gibi temel oyun geliştirme disiplinleri bir araya getirilmiştir. Hazır varlıklar (Assets) ve özelleştirilmiş tasarımlarla zenginleştirilen bu çalışma, bir oyunun hem teknik arka planını hem de görsel sunumunu kapsayan bütünsel bir yaklaşımla hazırlanmıştır. Şimdi bu projeyi daha detaylı 

1. Prefab (Önizlemeli Nesne) 

Kullanım Alanı: Düşman birimleri (Enemy) ve görsel efektler (Particle System). 

Açıklama: Sahnede tekrar eden nesneleri birer şablon haline getirdik. Bu sayede GameManager her seferinde yeni bir nesne tasarlamak yerine, mevcut "kalıbı" kullanarak belleği daha verimli yönetti ve projeyi düzenli tuttu. 

2. Vector3 ve Quaternion 

Kullanım Alanı: Karakter bakış açısı, hareket yönü ve rotasyon hesaplamaları. 

Açıklama: * Vector3: Uzaydaki 3 boyutlu konum (x, y, z) ve yön bilgisi için kullanıldı. Düşmanın oyuncuya olan mesafesini ve gidiş yönünü hesapladık. 

Quaternion: Unity'de dönüş (rotasyon) hesaplamaları için kullanılır. Kameranın yukarı-aşağı eğilme hareketini, Gimbal Lock (eksen kilitlenmesi) sorununu önleyen Quaternion.Euler yöntemiyle gerçekleştirdik. 

3. Partikül Efektleri (Particle Systems) 

Kullanım Alanı: Düşman yok edildiğinde oluşan patlama efekti. 

Açıklama: Oyuncuya görsel bir geri bildirim (feedback) vermek amacıyla, düşmanın öldüğü koordinatlarda anlık bir parçacık sistemi tetikledik. 

4. Instantiate 

Kullanım Alanı: Dinamik nesne oluşturma (GameManager.cs ve EnemyAI.cs). 

Açıklama: Çalışma zamanında (Runtime) kod aracılığıyla nesne üretmek için kullanıldı. Düşmanların belirli noktalarda doğması ve mermi/patlama efektlerinin oluşturulması bu komutla sağlandı. 

5. RayCast (Işın İzleme) 

Kullanım Alanı: Ateş etme mekanizması (Shoot() fonksiyonu). 

Açıklama: Kameranın merkezinden ileriye doğru görünmez, sonsuz (veya belirli bir uzunlukta) bir fizik ışını gönderdik. Physics.Raycast ile bu ışının çarptığı nesneleri tespit edip, çarpan nesnenin "Enemy" tag'ine sahip olup olmadığını kontrol ettik. 

6. FixedUpdate 

Kullanım Alanı: Fizik tabanlı düşman takibi (EnemyAI.cs). 

Açıklama: Standart Update kare hızına (FPS) bağlıyken, FixedUpdate sabit zaman aralıklarıyla çalışır. Fizik hesaplamalarının ve karakter takibinin daha stabil olması, titremelerin önlenmesi için bu yöntemi tercih ettik. 

7. Time.deltaTime 

Kullanım Alanı: Kare hızından bağımsız hareket. 

Açıklama: Hareket kodlarını saniye bazına yaymak için kullandık. Bu sayede oyun saniyede 30 FPS alan bilgisayarda da, 144 FPS alan bilgisayarda da aynı hızda akar; hareketin hızı işlemci gücüne göre değişmez. 

8. Arrays (Diziler) 

Kullanım Alanı: Doğuş noktalarının yönetimi (spawnPoints). 

Açıklama: Transform[] dizisi kullanarak sahnedeki tüm spawn noktalarını tek bir çatı altında topladık. Rastgele bir index seçerek (Random.Range) düşmanların farklı yerlerde doğmasını sağladık. 

9. Collision Detection (Çarpışma Algılama) 

Kullanım Alanı: Hasar alma mekanizması (OnCollisionEnter). 

Açıklama: Rigidbody ve Collider bileşenlerini kullanarak iki nesnenin fiziksel temasını algıladık. Düşman oyuncuya değdiği anda tetiklenen bu fonksiyonla can azaltma ve nesne yok etme (Destroy) işlemlerini yaptık. 

10. Animation - Animator Parametreleri 

Kullanım Alanı: Silah geri tepme ve ateşleme görseli. 

Açıklama: Kod tarafındaki bir olayı (Shoot fonksiyonu), görsel bir animasyona bağlamak için SetTrigger kullandık. Bu, Animator state machine üzerindeki geçişleri (Transition) tetikleyerek akıcı bir oyun deneyimi sundu. 

11. UI (User Interface)  

Kullanım Alanı: Ekranın tam ortasındaki nişangah (Crosshair) ve arayüzde. 

Açıklama: Bir Canvas oluşturduk ve tam merkeze bir Image (Görsel) ekleyerek oyuncunun hedef alabileceği bir nişangah tasarladık. 

12. Asset Kullanımı ve Görsel Özelleştirme 

Kullanım Alanı: Düşman modelleri, oyuncu tasarımı ve harita dekorasyonunda. 

Açıklama: Dışarıdan çeşitli asset paketleri ekleyerek projedeki basit şekilleri (küp, kapsül vb.) daha profesyonel ve özel tasarımlı 3D modellerle değiştirdik; oyunun atmosferini güçlendirdik. 

 
