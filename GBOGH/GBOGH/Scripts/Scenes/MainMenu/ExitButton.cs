using EX04OOP;

namespace GBOGH.Scripts.Scene.MainMenu;

public class ExitButton : Button
{
    public ExitButton(string name) : base(name)
    {
        this.OnButtonClick += Exit;
    }

    private void Exit()
    {
        SceneManager.Exit = true;
    }
}