Computer pc = new Computer();
GPU gpu = new GPU(pc);
RAM ram = new RAM(gpu);
SSD ssd = new SSD(ram);

Console.WriteLine(ssd);
