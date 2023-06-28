// Future of Rust

fn main() {
    println!("The Future is Now");

    // Programmatic Manipulation of Data
    let mut data: [u32; 4] = [3, 2, 5, 4];
    data.sort();
    let largest_number = data[3];
    print!("The largest number in the array is {}: ", largest_number);
    
    for x in data.iter() {
        if x == &largest_number {
            println!("{} - yes!", x);
        } else {
            println!("{}", x);
        }
    }
    
    // Concurrency
    let mut threads = vec![];
    let num_threads = 4;
    
    for i in 0..num_threads {
        let thread = thread::spawn(|| {
            println!("Thread {} executing...", i);
        });
        threads.push(thread);
    }
    
    for thread in threads {
        thread.join().unwrap();
    }
    
    println!("All threads have finished executing!");
    
    // Error Handling and Debugging
    let a = [1, 2, 3, 4, 5];
    if let Some(elem) = a.get(10) {
        println!("Element at index 10 is {}", elem);
    }
    
    match a.get(10) {
        Some(elem) => {
            println!("Element at index 10 is {}", elem);
        },
        None => {
            println!("Element at index 10 does not exist!");
        }
    }
    
    // Memory Management
    let mut v: Vec<i32> = Vec::new();
    for i in 0..100 {
        let x = Box::new(i * 2);
        v.push(*x);
    }
    drop(v);
    
    // Traits
    trait Area {
        fn area(&self) -> u32;
    }

    #[derive(Debug)]
    struct Square {
        side: u32,
    }
    
    impl Area for Square {
        fn area(&self) -> u32 {
            self.side * self.side
        }
    }
    
    let s = Square { side: 3 };
    println!("The area of the square is {}", s.area());

    // Macros
    macro_rules! squared {
        ($x:expr) => {
            $x * $x
        };
    }

    let y = 3;
    let y_squared = squared!(y);
    println!("The value of y squared is {}", y_squared);
    
    // Web Applications
    fn serve_webpage() {
        println!("Serving a web page!");
        println!("<html>");
        println!("<head>");
        println!("<title>The Future is Now</title>");
        println!("</head>");
        println!("<body>");
        println!("<h1>Welcome to the Future</h1>");
        println!("</body>");
        println!("</html>");
    }
    
    serve_webpage();
    
    // Java Interop
    extern "C" {
        fn java_method();
    }
    
    unsafe {
        java_method();
    }

}