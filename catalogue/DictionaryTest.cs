string? type, color, size;
string sku = "02-MN-L";
string[] product = sku.Split('-');

Dictionary<String, String> skuProductMap = new() {
    {"01", "Sweatshirt"},
    {"02", "T-Shirt"},
    {"03", "Sweatpants"}
};

Dictionary<String, String> skuColorMap = new() {
    {"BL", "Black"},
    {"MN", "Maroon"}
};

Dictionary<String, String> skuSizeMap = new() {
    {"S", "Small"},
    {"M", "Medium"},
    {"L", "Large"}
};

if (!skuProductMap.TryGetValue(product[0], out type)) {
    type = "Other";
};
if (!skuColorMap.TryGetValue(product[1], out color)) {
    color = "White";
};
if (!skuSizeMap.TryGetValue(product[2], out size)) {
    size = "One Size Fits All";
};

Console.WriteLine($"Product: {size} {color} {type}");