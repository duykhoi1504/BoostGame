
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay;
    private Vector3 spawnPos;
    AudioSource audi;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem SuccessPa;
    [SerializeField] ParticleSystem ExplosionPa;



     bool isTransitioning=false;
    private void Awake()
    {
        spawnPos = this.transform.position;
        audi=GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(isTransitioning)return;
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                StartCrashSequence();
                break;
            case "finish":
                StartSuccessSequence();
                break;
            default:
                break;

        }
    }
    void StartSuccessSequence(){
        isTransitioning=true;
        audi.Stop();
        audi.PlayOneShot(success);
        SuccessPa.Play();
         GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    void StartCrashSequence()
    {
        isTransitioning=true;
        audi.Stop();
        ExplosionPa.Play();
        audi.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", levelLoadDelay);
    }
    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //GetActiveScene(): Hàm này trả về Scene hiện tại mà người chơi đang chơi trong game
        //buildIndex:  trả về chỉ số (index) của Scene 
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
        // void DefaultStartPos(){
    // this.transform.position=spawnPos;
    // Quaternion rote=Quaternion.Euler(0,0,0);
    // this.transform.rotation=rote;
    // this.gameObject.GetComponent<Movement>().GetComponent<Rigidbody>().isKinematic=true;
    // this.gameObject.GetComponent<Movement>().GetComponent<Rigidbody>().isKinematic=false;
    // }
    
}
