const express = require("express");
const mongoose = require("mongoose");
const helmet = require("helmet");
const morgan = require("morgan");

const userRoute = require("./routes/users");
const authRoute = require("./routes/auth");
const postRoute = require("./routes/posts");

//dotenv.config();

async function start() {
  await new Promise((resolve, reject) => {
    mongoose.connect("mongodb://localhost:27017/to-be-or-not2", {
      useNewUrlParser: true,
      useUnifiedTopology: true,
    });

    const db = mongoose.connection;
    db.once("open", () => {
      console.log("Database connected");
      resolve();
    });
    db.on("error", (err) => reject(err));
  });

  const app = express();

  // app.use("/images", express.static(path.join(__dirname, "public/images")));

  // middleware

  app.use(cors());
  app.use(express.json());
  app.use(helmet());
  app.use(morgan("common"));

  /*
  const storage = multer.diskStorage({
    destination: (req, file, cb) => {
      cb(null, "public/images");
    },
    filename: (req, file, cb) => {
      cb(null, req.body.name);
    },
  });

  const upload = multer({ storage });
  
  app.post("/api/upload", upload.single("file"), (req, res) => {
    try {
      return res.status(200).json("File uploaded successfully.");
    } catch (err) {
      console.log(err);
    }
  });
  */
  
  app.use("/api/users", userRoute);
  app.use("/api/auth", authRoute);
  app.use("/api/posts", postRoute);

  app.listen(8800, () => {
    console.log(`Listening at http://localhost:${8800}`);
  });
}

/*

const app = express();

mongoose.connect(
  "mongodb://localhost/to-be-or-not",
  {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  },
  () => {
    console.log("Connected to MongoDB");
  }
);

app.use("/images", express.static(path.join(__dirname, "public/images")));

// middleware

app.use(express.json());
app.use(helmet());
app.use(morgan("common"));
app.use(
  cors({
    origin: "http://localhost:3000",
  })
);

const storage = multer.diskStorage({
  destination: (req, file, cb) => {
    cb(null, "public/images");
  },
  filename: (req, file, cb) => {
    cb(null, req.body.name);
  },
});

const upload = multer({ storage });
app.post("/api/upload", upload.single("file"), (req, res) => {
  try {
    return res.status(200).json("File uploaded successfully.");
  } catch (err) {
    console.log(err);
  }
});

app.use("/api/users", userRoute);
app.use("/api/auth", authRoute);
app.use("/api/posts", postRoute);

app.listen(8800, () => {
  console.log(`Listening at http://localhost:${8800}`);
});

*/
