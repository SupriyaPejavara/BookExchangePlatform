import React from "react";
import { Box, Paper, Tab, Tabs, Typography, useTheme } from "@material-ui/core";
import { useStyles } from "./search-tabs.styles";
import { TabPanel } from "../tab-panel";
import { FilteredSearch } from "./filtered-search";
import { Book } from "types";
interface SearchTabsProps {
  page: number;
  setTotalRecords: React.Dispatch<React.SetStateAction<number>>;
  rowsPerPage: number;
  setBooks: React.Dispatch<React.SetStateAction<Book.Book[] | undefined>>;
  isActiveSearch: any;
  setActiveSearch: any;
}

const SearchTabs = (props: SearchTabsProps) => {
  const classes = useStyles();
  const theme = useTheme();

  const [value, setValue] = React.useState(0);

  const handleChange = (event: React.ChangeEvent<{}>, newValue: number) => {
    setValue(newValue);
  };

  const handleChangeIndex = (index: number) => {
    setValue(index);
  };

  return (
    <Paper className={classes.root}>
      <Tabs
        value={value}
        onChange={handleChange}
        indicatorColor="primary"
        textColor="primary"
        variant="fullWidth"
      >       
        <Tab label="Advanced Search" />
      </Tabs>       
        <TabPanel value={value} index={0} dir={theme.direction}>
          <FilteredSearch
            {...props}
            isActiveSearch={props.isActiveSearch}
            setActiveSearch={props.setActiveSearch}
          />
        </TabPanel>      
    </Paper>
  );
};

export { SearchTabs };
