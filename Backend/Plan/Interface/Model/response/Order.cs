namespace plan.Backend.Plan.Interface.model;

public record Order(string OrderCode);

public record WeavingOrder(string WeavingCode, string OrderCode, string StyleCode);

