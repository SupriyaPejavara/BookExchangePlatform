import React from "react";
import { Container, Paper, Typography, Box } from "@material-ui/core";
import book9 from "images/book9.jpg";
import { useStyles } from "./home-page-styles";
import { RecommendedBooks } from "components/recommended-books";
import InfoIcon from "@material-ui/icons/Info";

const HomePage = () => {
  const classes = useStyles();
  return (
    <div className={classes.root}>
      <Box mb={10}>
        <Container>
          <Paper>
            <img src={book9} className={classes.topImage} />
          </Paper>
        </Container>
      </Box>

      <Box my={2}>
        <Container>
          <RecommendedBooks />
        </Container>
      </Box>

      <Box my={3}>
        <Container>
          <Paper>
            <Box p={3}>
              <Typography variant="h6" className={classes.aboutUs}> <InfoIcon className={classes.icon} />About Us</Typography>
              <h1></h1>
              <Typography variant="body1">
                Our book exchange platform provides users with a convenient and 
                efficient way to discover new reading material, share their favorite books with others, 
                and connect with fellow book enthusiasts in their community. 
                The platform aims to promote a reading culture and foster a sense of 
                community among users by facilitating book exchanges.
              </Typography>
            </Box>
          </Paper>
        </Container>
      </Box>
    </div>
  );
};

export { HomePage };
