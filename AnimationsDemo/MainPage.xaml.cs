namespace AnimationsDemo;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCancelAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce("Cancel animation");
        dotNetBotImage.CancelAnimations();
    }

    private async void ResetProperties()
    {
        await Task.Delay(1000);
        dotNetBotImage.Rotation = 0;
        dotNetBotImage.Scale = 1;
        dotNetBotImage.TranslationX = 0;
        dotNetBotImage.TranslationY = 0;
        dotNetBotImage.Opacity = 1;
    }

    private void ChangeAnimationLabel(string text)
    {
        AnimationLabel.Text = text;
    }

    private async void OnFadeAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        ChangeAnimationLabel("FadeTo");
        await dotNetBotImage.FadeTo(0, 500);
        await dotNetBotImage.FadeTo(1, 500);
        ResetProperties();
    }

    private async void OnRotateAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        ChangeAnimationLabel("Rotate");
        await dotNetBotImage.RotateTo(360, 500);
        ResetProperties();
    }

    private async void OnScaleAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        ChangeAnimationLabel("Scale");
        await dotNetBotImage.ScaleTo(2, 500);
        await dotNetBotImage.ScaleTo(1, 500);
        ResetProperties();
    }

    private async void OnTranslateAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        ChangeAnimationLabel("Translate");
        await dotNetBotImage.TranslateTo(-200, 0, 500);
        await dotNetBotImage.TranslateTo(0, 0, 500);
        ResetProperties();
    }

    private async void OnCompositeAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        ChangeAnimationLabel("Rotate and Scale");
        // Composite animation
        // A composite animation is a combination of animations where two or more
        // animations run simultaneously.
        // Composite animations can be created by combining awaited and non-awaited animations:
        // Set Rotation to 0, otherwise the second time this animation runs, it won't rotate.
        dotNetBotImage.Rotation = 0;
        dotNetBotImage.RotateTo(360, 1000);
        await dotNetBotImage.ScaleTo(2, 500);
        await dotNetBotImage.ScaleTo(1, 500);
        ResetProperties();
    }

    private async void OnEasingBounceOutAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        ChangeAnimationLabel("Easing BounceOut");
        // This one took a little time to figure out. The last +25 is there because of the
        // Spacing="25" in the StackLayout setup. It works with any screen size.
        var translateToCoordinateY = Height 
            - dotNetBotImage.Height - (dotNetBotImage.Height / 2) + 25;
        await dotNetBotImage.TranslateTo(0, translateToCoordinateY, 2000, Easing.BounceOut);
        ResetProperties();
    }
}