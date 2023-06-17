namespace Tick.Yage;

public interface ISceneManager
{
    void OnSceneEvent(object _, EventArgs e);
    void LoadScene<TScene>(GameSceneView view) where TScene : Scene;
}