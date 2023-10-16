import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Rating from "@mui/material/Rating";
import Button from "@mui/material/Button";
import { useState } from "react";
import Navbar from "./components/Navbar";

function App() {
  const [ratingValue, setRatingValue] = useState<number | null>(null);
  const [comment, setComment] = useState<string>("");
  const [submitsCount, setSubmitsCount] = useState<number>(0);

  const isDisabled = ratingValue === null || comment === "";

  return (
    <Box
      sx={{
        width: "100vw",
        display: "flex",
        justifyContent: "center",
      }}
    >
      <Navbar />

      <Box
        sx={{
          width: "100%",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Typography>How would you rate this experience?</Typography>
        <Rating
          value={ratingValue}
          onChange={(_, value) => setRatingValue(value)}
        />
        <Typography>Tell us how it went.</Typography>
        <TextField
          sx={{ width: "25%" }}
          multiline
          maxRows={4}
          value={comment}
          onChange={(e) => setComment(e.target.value)}
        ></TextField>
        <Button
          disabled={isDisabled}
          sx={{ mt: 1 }}
          variant="contained"
          onClick={() => {
            setSubmitsCount((count) => count + 1);
          }}
        >
          Submit {submitsCount}
        </Button>
      </Box>
    </Box>
  );
}

export default App;
