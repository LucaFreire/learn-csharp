
// Classe
PointClass pc = new PointClass(10,20);
Console.WriteLine("Classe criada");
pc.ShowValues();
ModifyClassValues(pc);
Console.WriteLine("Classe modificada");
pc.ShowValues();

// Struct
PointStruct st = new PointStruct(10,20);
Console.WriteLine("\nStruct criada");
st.ShowValues();
ModifyStructValues(st);
Console.WriteLine("Struct modificada");
st.ShowValues();



static void ModifyClassValues(PointClass pc)
{
    pc.no1 += 10;
    pc.no2 += 10;
}

static void ModifyStructValues(PointStruct st)
{
    st.no1 += 10;
    st.no2 += 10;
}
