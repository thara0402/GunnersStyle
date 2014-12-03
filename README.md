GunnersStyle
======================
Aesthetics unchanged, Belief not to bend.

GunnersStyle.Instapaper
------
[Instapaper Simple API](https://www.instapaper.com/api/simple) Client Library.

    Install-Package GunnersStyle.Instapaper
#### Authentication:
```C#
await InstapaperHelper.AuthenticateAsync("userName", "password");
```
#### Adding URLs to an Instapaper account:
```C#
await InstapaperHelper.AddAsync("userName", "password", "uri");
```
