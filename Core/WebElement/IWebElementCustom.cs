namespace Core.WebElement;

public interface IWebElementCustom
{
    public void Click();
    public void SendKeys(string keys);
    public void Clear();
    public void Submit();
    public string Text();
}