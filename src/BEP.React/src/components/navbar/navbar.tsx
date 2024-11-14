import React, { useState, useEffect, useContext } from "react";
import {
  AppBar,
  Button,
  Drawer,
  IconButton,
  MenuItem,
  Toolbar,
  Typography,
  useMediaQuery,
  useTheme,
} from "@material-ui/core";
import { Link } from "@material-ui/core";
import { isClassExpression } from "typescript";
import { Link as RouterLink } from "react-router-dom";
import MenuIcon from "@material-ui/icons/Menu";
import { ModalDialog } from "./components/modal-dialog";
import { AuthContext } from "../../context";
import { Userbar } from "../../components/userbar";
import { useStyles } from "./navbar.styles";
import HomeIcon from '@material-ui/icons/Home';
import SearchIcon from '@material-ui/icons/Search';
import AddIcon from '@material-ui/icons/Add';

const headersData = [
  {
    label: "Home",
    href: "/",    
  },
  {
    label: "Search Books",
    href: "/search",
  },
  {
    label: "Add book",
    href: "/add-book",
  },
];

const Navbar = () => {
  const [drawerOpen, setDrawerOpen] = useState(false);
  const [signUpOpen, setSignUpOpen] = useState(false);
  const [activeButton, setActiveButton] = useState("Home");
  const classes = useStyles();
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down("xs"));
  const authContext = useContext(AuthContext);
  const handleSignUpOpen = () => {
    setSignUpOpen(true);
  };

  const handleSignUpClose = () => {
    setSignUpOpen(false);
  };

  const displayDesktop = () => {
    return (      
       <><Toolbar className={classes.toolbar}>
       {bookExchangeLogo}
       <Userbar />
       </Toolbar> </>        
     );
  };

  const displayMobile = () => {
    const handleDrawerOpen = () => {
      setDrawerOpen(true);
    };
    const handleDrawerClose = () => {
      setDrawerOpen(false);
    };
    const handleButtonClick = (label: string) => {
      setActiveButton(label);
    };

    return (
      <Toolbar>
        <IconButton
          {...{
            edge: "start",
            color: "inherit",
            "aria-label": "menu",
            "aria-haspopup": "true",
            onClick: handleDrawerOpen,
          }}
        >
          <MenuIcon />
        </IconButton>

        <Drawer
          {...{
            anchor: "left",
            open: drawerOpen,
            onClose: handleDrawerClose,
          }}
        >
          <div>{getDrawerChoices()}</div>
        </Drawer>

        <div>{bookExchangeLogo}</div>
      </Toolbar>
    );
  };

  const getDrawerChoices = () => {
    return headersData.map(({ label, href }) => {
      return (
        <Link
          {...{
            component: RouterLink,
            to: href,
            color: "inherit",
            style: { textDecoration: "none" },
            key: label,
          }}
        >
          <MenuItem>{label}</MenuItem>
        </Link>
      );
    });
  };

  const bookExchangeLogo = (
    <Typography variant="h6" component="h1" className={classes.logo}>
      Book Exchange Platform
    </Typography>
  );
  
  const handleButtonClick = (label: string) => {
    setActiveButton(label);
  };

  const getMenuButtons = () => {
    let buttons = headersData.map(({ label, href }) => {
      return (
        <Button
          {...{
            key: label,
            color: "inherit",
            to: href,
            component: RouterLink,           
          }}
          startIcon= {label=="Home"? <HomeIcon /> : label=="Search Books"? <SearchIcon /> : <AddIcon />}
          color={activeButton === label ? "primary" : "inherit"}  
          onClick={() => handleButtonClick(label)}     
        >
          {label}
        </Button>        
      );      
    });

    let signUpButton = (
      <Button color="inherit" onClick={handleSignUpOpen}>
        {" "}
        Sign Up
      </Button>
    );

    return <>{buttons}</>;
  };

  const getMenuItems = () => {
    return headersData.map(({ label, href }) => {
      return (
        <Button
          {...{
            key: label,
            color: "inherit",
            to: href,
            component: RouterLink,
          }}
        >
          {label}
        </Button>
      );
    });
  };

  return (
    <><header>
      <AppBar className={classes.header}>
        {isMobile ? displayMobile() : displayDesktop()}
      </AppBar>
      <ModalDialog open={signUpOpen} handleClose={handleSignUpClose} />
    </header>
    <h1>.......</h1>
    <Toolbar className={classes.toolbar}>
        {authContext.isLoggedIn ? (
          <>{getMenuButtons()}</>
        ) : (<></>)}
      </Toolbar></>
  );
};

export { Navbar };
