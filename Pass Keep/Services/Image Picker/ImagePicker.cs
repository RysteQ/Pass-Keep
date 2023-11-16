using System.Runtime.CompilerServices;

namespace Pass_Keep.Services.Image_Picker;

internal static class ImagePicker
{
    public static async Task<FileResult> PickImage()
    {
        FileResult picked_image;

        PickingImage = true;
        picked_image = await MediaPicker.PickPhotoAsync();

        return picked_image;
    }

    private static bool picking_image;
    public static bool PickingImage
    {
        get
        {
            bool to_return = picking_image;
            picking_image = false;

            return to_return;
        }

        private set => picking_image = value;
    }
}