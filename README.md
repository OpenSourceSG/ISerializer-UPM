# ISerializer

![License: Unlicense](https://img.shields.io/badge/license-Unlicense-blue.svg)
![Unity](https://img.shields.io/badge/unity-2021.3%2B-green.svg)
![GitHub release (latest by date)](https://img.shields.io/github/v/release/OpenSourceSG/ISerializer)
[![YouTube Tutorial](https://img.shields.io/badge/YouTube-Tutorial-red?logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCkcyY4bx0KkkorMIs_lBtLg)

**ISerializer** is a unity editor extension that allows you to serialize **interface references** directly in the unity inspector. With a simple attribute and property drawer, you can assign any component implementing a given interface, removing the restriction of concrete types.

---

## Why Use It?

Unity does not natively support serialization of interfaces in the Inspector. This package solves that by:

* Enabling interface-driven design in Unity projects.
* Providing a dropdown of all matching components in the scene.
* Maintaining type safety and avoiding runtime casting errors.
* Eliminating boilerplate code for manually wiring interface references.

---

## Features

* `[ISerialize]` attribute for interface fields.
* Inspector integration with dropdown selection.
* Compatible with Unity 2021+ and newer (2023 support included).
* Lightweight, dependency-free, and editor-only.

---

## How to Install

### Option 1: Unity Package Manager (Git URL)

1. Open Unity.
2. Go to **Window > Package Manager**.
3. Click **+ > Add package from git URL**.
4. Enter:

   ```
   https://github.com/OpenSourceSG/ISerializer-UPM.git
   ```

> [!NOTE]
> This will install package into **Package/** folder.


### Option 2: Unity Package Manager (Manual Import)

1. Download or clone this repository.
2. Go to **Window > Package Manager**.
3. Click **+ > Add package from disk**.
4. Go to folder where you cloned or downloaded the repository and open the **package.json** file.

> [!NOTE]
> This will install package into **Package/** folder.


### Option 3: Importing as Unity Asset 

1. Go to:

   ```
   https://github.com/OpenSourceSG/ISerializer.git
   ```
2. Download or clone this repository.
3. Right Click on **Project Window > Import Package > Custom Package**.
4. Choose the folder or package and click on open

> [!NOTE]
> This will install package into **Assets/** folder.

---

## How to use

1. Create an interface like this.
```csharp
public interface IPet
{
    public void Run();
}
```

2. Implement interface like this.
```csharp
public class Cat : MonoBehaviour, IPet
{
    public void Run()
    {
        Debug.Log("[Cat] Running.....");
    }
}

public class Dog : MonoBehaviour, IPet
{
    public void Run()
    {
        Debug.Log("[Dog] Running.......");
    }
}
```

3. Use `ISerialize(typeof("Your Interface Type"))]` to serialize your interfaces as an `Object` or `MonoBehaviour`.
```csharp
public class Trainer : MonoBehaviour
{
    [ISerialize(typeof(IPet))] public Object Pet;
    private IPet _pet => Pet as IPet; 

    private void Start()
    {
        if (_pet == null)
        {
            Debug.LogError($"{nameof(Trainer)} requires a {nameof(IPet)}");
            return;
        }
        _pet.Run();
    }
}
```

4. Now in the Unity Inspector, the `Pet` field shows a dropdown with all components in the scene that implement `IPet`.

---

## License

This project is unlicensed. You may use, copy, modify, and distribute it without restriction. See the UNLICENSE file for details.